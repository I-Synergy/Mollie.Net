using Mollie.Models.Issuer;
using Mollie.Models.List;
using Mollie.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mollie.Tests
{
    [Collection(nameof(BaseApiTestFixture))]
    public class IssuerTests
    {
        protected BaseApiTestFixture fixture;

        public IssuerTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact]
        public async Task CanRetrieveIssuerList()
        {
            // When: Retrieve payment list with default settings
            ListResponse<IssuerResponse> issuerList = await fixture.IssuerClient.GetIssuerListAsync();

            // Then
            Assert.NotNull(issuerList);
        }
    }
}
