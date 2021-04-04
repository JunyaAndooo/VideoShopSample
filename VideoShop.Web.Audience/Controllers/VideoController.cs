using Microsoft.AspNetCore.Mvc;
using System;
using VideoShop.Application.Video.Download;

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
        /// 動画をダウンロードする
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <param name="videoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpGet(nameof(Download) + "/{audienceId}")]
        public IActionResult Download([FromRoute] Guid audienceId, [FromQuery] Guid videoId)
        {
            DownloadInputData inputData = new(
                AudienceId:
                    audienceId,
                VideoId:
                    videoId);
            DownloadOutputData downloadOutputData = this.downloadUseCase.Download(inputData);

            // ファイル接続キーを渡してクライアント側でうまいことやってもらうスタイル
            return Ok(downloadOutputData);
        }

        /// <summary>
        /// 動画をストリーミング視聴する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <param name="videoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpGet(nameof(Streaming) + "/{audienceId}")]
        public IActionResult Streaming([FromRoute] Guid audienceId, [FromQuery] Guid videoId)
        {
            // ストリーミング視聴どうやったらいいのか分からないので、省略

            return Ok();
        }
    }
}
