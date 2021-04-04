using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using VideoShop.Application.Video.ResisterDescription;
using VideoShop.Application.Video.ResiterExam;
using VideoShop.Application.Video.SaveVideo;

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
            IResiterExamUseCase resiterExamUseCase
        )
        {
            this.saveVideoUseCase = saveVideoUseCase;
            this.resiterExamUseCase = resiterExamUseCase;
        }

        /// <summary>
        /// MP4を登録する
        /// </summary>
        /// <param name="postedFile">アップロードファイル</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SaveVideo))]
        public IActionResult SaveVideo(IFormFile postedFile, [FromForm] string videoTitle)
        {
            // この辺でアップロードファイルを一時フォルダに保存（今回はClean Architectureの学習のため省略）
            string filePath = $"tmppath/{postedFile.FileName}";

            SaveVideoInputData inputData = new(
                TmpFilePath:
                    filePath,
                VideoTitle:
                    videoTitle);
            this.saveVideoUseCase.Save(inputData);
            return Ok();
        }

        /// <summary>
        /// 試験を登録する（動画情報に試験テキストを追加すると解釈）
        /// </summary>
        /// <param name="videoId">動画ID</param>
        /// <param name="exam">試験</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(ResisterExam))]
        public IActionResult ResisterExam([FromForm] Guid videoId, [FromForm] string exam)
        {
            ResiterExamInputData inputData = new(
                VideoId:
                    videoId,
                Exam:
                    exam);
            this.resiterExamUseCase.Resister(inputData);
            return this.Ok();
        }

        /// <summary>
        /// 動画の説明文を登録する
        /// </summary>
        /// <param name="videoId">動画ID</param>
        /// <param name="description">説明文</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(ResisterDescription))]
        public IActionResult ResisterDescription([FromForm] Guid videoId, [FromForm] string description)
        {
            ResisterDescriptionInputData inputData = new(
                VideoId:
                    videoId,
                Description:
                    description);
            this.resisterDescriptionUseCase.Resister(inputData);
            return this.Ok();
        }
    }
}
