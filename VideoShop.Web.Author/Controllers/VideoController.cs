using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using VideoShop.Application.Video.ResisterDescription;
using VideoShop.Application.Video.ResiterExam;
using VideoShop.Application.Video.SaveVideo;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Shared.Clients.Exceptions;

namespace VideoShop.Web.Author.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ISaveVideoUseCase saveVideoUseCase;
        private readonly IResiterExamUseCase resiterExamUseCase;
        private readonly IResisterDescriptionUseCase resisterDescriptionUseCase;

        public VideoController(
            ISaveVideoUseCase saveVideoUseCase,
            IResiterExamUseCase resiterExamUseCase,
            IResisterDescriptionUseCase resisterDescriptionUseCase
        )
        {
            this.saveVideoUseCase = saveVideoUseCase;
            this.resiterExamUseCase = resiterExamUseCase;
            this.resisterDescriptionUseCase = resisterDescriptionUseCase;
        }

        /// <summary>
        /// MP4を登録する（動画情報を追加すると解釈）
        /// </summary>
        /// <param name="postedFile">アップロードファイル</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SaveVideo))]
        public async ValueTask<ActionResult> SaveVideo(IFormFile postedFile, [FromForm] string videoTitle)
        {
            using MemoryStream uploadedMemoryStream = new();
            postedFile.CopyTo(uploadedMemoryStream);

            SaveVideoInputData inputData = new
                (
                    UploadedMemoryStream: uploadedMemoryStream,
                    UploadedFileName: postedFile.FileName,
                    VideoTitle: videoTitle
                );

            try
            {
                SaveVideoOutputData outputData = await this.saveVideoUseCase.Handle(inputData);
                return this.Ok(outputData);
            }
            catch (Exception e) when (e is FileUploadFailedException || e is VideoRegistrationFailedException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "予期しないエラーが発生しました");
            }
        }

        /// <summary>
        /// 試験を登録する（動画情報に試験テキストを追加すると解釈）
        /// </summary>
        /// <param name="videoId">動画ID</param>
        /// <param name="exam">試験</param>
        /// <returns>結果</returns>
        [HttpPut(nameof(ResisterExam))]
        public async ValueTask<ActionResult> ResisterExam([FromForm] Guid videoId, [FromForm] string exam)
        {
            ResiterExamInputData inputData = new
                (
                    VideoId: videoId,
                    Exam: exam
                );

            try
            {
                await this.resiterExamUseCase.Handle(inputData);
                return this.Ok();
            }
            catch (VideoNotFoundException)
            {
                return this.NotFound();
            }
            catch (VideoUpdateFailedException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "予期しないエラーが発生しました");
            }
        }

        /// <summary>
        /// 動画の説明文を登録する
        /// </summary>
        /// <param name="videoId">動画ID</param>
        /// <param name="description">説明文</param>
        /// <returns>結果</returns>
        [HttpPut(nameof(ResisterDescription))]
        public async ValueTask<ActionResult> ResisterDescription([FromForm] Guid videoId, [FromForm] string description)
        {
            ResisterDescriptionInputData inputData = new
                (
                    VideoId: videoId,
                    Description: description
                );

            try
            {
                await this.resisterDescriptionUseCase.Handle(inputData);
                return this.Ok();
            }
            catch (VideoNotFoundException)
            {
                return this.NotFound();
            }
            catch (VideoUpdateFailedException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "予期しないエラーが発生しました");
            }
        }
    }
}
