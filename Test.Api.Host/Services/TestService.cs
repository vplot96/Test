using System.Collections.Generic;
using Test.Api.Host.Models.Entities;
using Test.Api.Host.Services.Contracts;

namespace Test.Api.Host.Services
{
	public class TestService : ITestService
	{
		private List<TestItem> _testItems;
		public TestService()
		{
			_testItems = new List<TestItem>() {
				new TestItem { Id = 1, Name = "name"},
				new TestItem { Id = 2, Name = "name"},
				new TestItem { Id = 3, Name = "name"},
			};
		}
		public TestItem Get(long id)
		{
			return _testItems.Find(x => x.Id == id);
		}

		public TestItem Get(string name)
		{
			return _testItems.Find(x =>x.Name == name);
		}

		public void Save(TestItem item)
		{
			_testItems.Add(item);
		}

		public void Delete(long id)
		{
			_testItems.Remove(Get(id));
		}
	}
}
