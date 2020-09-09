using FluentFolderizer.Results;
using System.Threading.Tasks;

namespace FluentFolderizer
{
    public interface IOrganizer
    {
        /// <summary>
        /// Executes the organization according to the provided preferences.
        /// </summary>
        OrganizationResult Run();

        /// <summary>
        /// Executes the organization asynchronously, according to the provided preferences.
        /// </summary>
        Task<OrganizationResult> RunAsync();
    }
}