using System.Collections.Generic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IProcessApplicationSpecificBehaviour,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
        Establish c = () =>
        {
            request = fake.an<IContainRequestInformation>();
        };

        Because b = () =>
        {
            sut.run(request);
            departments = sut.GetDepartments();
        };

        It should_return_a_list_of_departments = () =>
            departments.ShouldNotBeNull();

        static IContainRequestInformation request;
        static IEnumerable<IDepartment> departments;
    }
  }
}