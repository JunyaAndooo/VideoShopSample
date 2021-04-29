using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Video.Download;
using VideoShop.Domain.DomainModels.License.Exceptions;
using VideoShop.Domain.DomainModels.Video.Exceptions;

namespace VideoShop.Web.Audience.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IDownloadUseCase downloadUseCase;

        public VideoController(IDownloadUseCase downloadUseCase)
        {
            this.downloadUseCase = downloadUseCase;
        }

        /// <summary>
        /// 動画をダウンロードする（ファイル接続キーを渡してクライアント側でうまいことやってもらうスタイル）
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <param name="videoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpGet(nameof(Download) + "/{audienceId}")]
        public async ValueTask<ActionResult> Download([FromRoute] Guid audienceId, [FromQuery] Guid videoId)
        {
            DownloadInputData inputData = new
                (
                    AudienceId: audienceId,
                    VideoId: videoId
                );

            try
            {
                DownloadOutputData downloadOutputData = await this.downloadUseCase.Handle(inputData);

                return this.File(downloadOutputData.Stream, "video/mp4", downloadOutputData.FileName);
            }
            catch (LicenseIsNotValidException)
            {
                return this.NotFound("ライセンスが無効でした");
            }
            catch (VideoNotFoundException)
            {
                return this.NotFound("ライセンスが無効でした");
            }

        }

        /// <summary>
        /// 動画をストリーミング視聴する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <param name="videoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpGet(nameof(Streaming) + "/{audienceId}")]
        public async ValueTask<ActionResult> Streaming([FromRoute] Guid audienceId, [FromQuery] Guid videoId)
        {
            // ストリーミング視聴は今回の趣旨ではないので、省略

            return this.Ok();
        }
    }
}
