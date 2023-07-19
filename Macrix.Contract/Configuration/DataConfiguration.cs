using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrix.Contract.Configuration
{
    public class DataConfiguration
    {
        public const string DataConfigurationName = nameof(DataConfiguration);
        public required string FilePath { get; set; }
    }
}
