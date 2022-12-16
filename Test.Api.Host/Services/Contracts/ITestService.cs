using Test.Api.Host.Models.Entities;

namespace Test.Api.Host.Services.Contracts
{
	public interface ITestService
	{
		TestItem Get(long id);
		TestItem Get(string name);
		void Save(TestItem item);
		void Delete(long id);
	}
}
