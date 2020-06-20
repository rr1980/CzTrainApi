using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CzTrainApi.ViewModels.Test
{
    public class TestRequestVM
    {
        /// <summary>
        /// AnredId
        /// </summary>
        [Required]
        public long Id { get; set; }
    }

    public class TestAnredeResponseVM
    {
        public long Id { get; set; }
        public string Bezeichnung { get; set; }

        public IList<TestAnredePersonResponseVM> Personen { get; set; }
    }

    public class TestAnredePersonResponseVM
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Benutzername { get; set; }
        public string Titel { get; set; }
    }
}
