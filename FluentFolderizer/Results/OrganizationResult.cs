using System;
using System.Collections.Generic;

namespace FluentFolderizer.Results
{
    public class OrganizationResult
    {
        private IList<Failure> _failures;
        public IList<Failure> Failures 
        {
            get => _failures ?? (_failures = new List<Failure>());
        }

        public void AddFailure(string file, Exception ex)
        {
            if (file is null || ex is null)
                throw new ArgumentNullException();

            this.Failures.Add(new Failure(file, ex));
        }
    }

}