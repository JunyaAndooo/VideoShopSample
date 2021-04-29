using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Video.AddVideoToSeries;
using VideoShop.Application.Video.RemoveVideoToSeries;
using VideoShop.Domain.DomainModels.Video.Exceptions;

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
        /// シリーズに動画を公開する（シリーズに動画を追加すると解釈）
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpPut(nameof(AddVideoToSeries))]
        public async ValueTask<ActionResult> AddVideoToSeries([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            AddVideoToSeriesInputData inputData = new
                (
                    SeriesId: SeriesId,
                    VideoId: VideoId
                );

            try
            {
                await this.addVideoToSeriesUseCase.Handle(inputData);

                return this.Ok();
            }
            catch (VideoNotFoundException)
            {
                return this.NotFound("ビデオ情報が見つかりませんでした");
            }
            catch (VideoNotUpdatedException)
            {
                return this.NotFound("すでに更新されていました");
            }
        }

        /// <summary>
        /// シリーズから動画を削除する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpDelete(nameof(RemoveVideoToSeries))]
        public async ValueTask<ActionResult> RemoveVideoToSeries([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            RemoveVideoToSeriesInputData inputData = new
                (
                    SeriesId: SeriesId,
                    VideoId: VideoId
                );

            try
            {
                await this.removeVideoToSeriesUseCase.Handle(inputData);
                return this.Ok();
            }
            catch (Exception e) when (e is VideoNotFoundException || e is SeriesWasNotRegisteredException)
            {
                return this.NotFound("ビデオ情報が見つかりませんでした");
            }
            catch (VideoNotUpdatedException)
            {
                return this.NotFound("すでに削除されていました");
            }
        }
    }
}
