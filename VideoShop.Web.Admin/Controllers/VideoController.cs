using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Video.AddVideoToSeries;
using VideoShop.Application.Video.RemoveVideoToSeries;

namespace VideoShop.Web.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IAddVideoToSeriesUseCase addVideoToSeriesUseCase;
        private readonly IRemoveVideoToSeriesUseCase removeVideoToSeriesUseCase;

        public VideoController(
            IAddVideoToSeriesUseCase addVideoToSeriesUseCase,
            IRemoveVideoToSeriesUseCase removeVideoToSeriesUseCase
        )
        {
            this.addVideoToSeriesUseCase = addVideoToSeriesUseCase;
            this.removeVideoToSeriesUseCase = removeVideoToSeriesUseCase;
        }

        /// <summary>
        /// シリーズに動画を公開する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(AddVideoToSeries))]
        public async ValueTask<ActionResult> AddVideoToSeries([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            AddVideoToSeriesInputData inputData = new
                (
                    SeriesId: SeriesId,
                    VideoId: VideoId
                );
            await this.addVideoToSeriesUseCase.Add(inputData);

            return this.Ok();
        }

        /// <summary>
        /// シリーズから動画を削除する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(RemoveVideoToSeries))]
        public async ValueTask<ActionResult> RemoveVideoToSeries([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            RemoveVideoToSeriesInputData inputData = new
                (
                    SeriesId: SeriesId,
                    VideoId: VideoId
                );
            await this.removeVideoToSeriesUseCase.Remove(inputData);

            return this.Ok();
        }
    }
}
