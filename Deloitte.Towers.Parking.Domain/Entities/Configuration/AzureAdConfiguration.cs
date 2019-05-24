using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Entities.Configuration
{
    public class AzureAdConfiguration
    {
        public string IdaTenant { get; set; }
        public string IdaAuthority { get; set; }
        public string IdaIssuer { get; set; }
        public string IdaRedirectUriPattern { get; set; }
        public string IdaClient { get; set; }
        public string IdaAudienceOrAppIdUri { get; set; }
    }
}
