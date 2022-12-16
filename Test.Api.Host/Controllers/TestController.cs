using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Test.Api.Host.Models.Entities;
using Test.Api.Host.Services;
using Test.Api.Host.Services.Contracts;
using Test.Api.Host.Services.Entities;

namespace Test.Api.Host.Controllers
{
	[ApiController]
	[Route("api/test")]
	public sealed class TestController : ControllerBase
	{
		private readonly ITestService _testService;
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();

		public TestController(ITestService testService)
		{
			_testService = testService;
		}

		[HttpGet]
		[Route("getById")]
		public ActionResult<TestItem> GetTestItemById(long id)
		{
			_logger.Info($"Executing GetTestItemById id = {id}");
			return Ok(_testService.Get(id));
		}

		[HttpGet]
		[Route("getByName")]
		public ActionResult<TestItem> GetTestItemByName(string name)
		{
			_logger.Info($"Executing GetTestItemById name = {name}");
			return Ok(_testService.Get(name));
		}

		[HttpPost]
		[Route("add")]
		public ActionResult AddTestItem([FromBody] AddTestItemRequest request)
		{
			_testService.Save(new TestItem { Id = request.Id, Name = request.Name });
			return Ok();
		}

		[HttpDelete]
		[Route("delete")]
		public ActionResult DeleteTestItem(long id)
		{
			_testService.Delete(id);
			return Ok();
		}
	}
}
