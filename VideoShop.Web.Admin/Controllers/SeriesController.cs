using Microsoft.AspNetCore.Mvc;
using System;
using VideoShop.Application.Series;

namespace VideoShop.Web.Admin.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ICreateSeriesUseCase createSeriesUseCase;

        public SeriesController(ICreateSeriesUseCase createSeriesUseCase)
        {
            this.createSeriesUseCase = createSeriesUseCase;
        }

        [HttpPost(nameof(CreateSeries))]
        public IActionResult CreateSeries([FromForm] string seriesName)
        {
            CreateSeriesInputData inputData = new(seriesName);
            this.createSeriesUseCase.Save(inputData);

            return Ok();
        }

        [HttpPost(nameof(SeriesAddVideo))]
        public IActionResult SeriesAddVideo([FromForm] Guid SeriesId, Guid VideoId)
        {

            return Ok();
        }

        [HttpPost(nameof(SeriesRemoveVideo))]
        public IActionResult SeriesRemoveVideo([FromForm] Guid SeriesId, Guid VideoId)
        {

            return Ok();
        }

        [HttpPost(nameof(SeriesSetLicense))]
        public IActionResult SeriesSetLicense([FromForm] Guid SeriesId, decimal LicensePrice)
        {

            return Ok();
        }
    }
}
