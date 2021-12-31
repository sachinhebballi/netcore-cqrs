using System;

namespace Api.Common.Models.Common
{
    public class Version
    {
        public DateTime VersionGroup { get; set; }

        public int Major { get; set; }

        public int Minor { get; set; }

        /// <summary>
        /// alpha, beta, etc
        /// </summary>
        public string Status { get; set; }

        public override string ToString() => $"{this.Major}.{this.Minor}-{this.Status}";
    }
}
