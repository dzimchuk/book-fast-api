using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Facility = BookFast.Contracts.Models.Facility;

namespace BookFast.Data.Commands
{
    internal class CreateFacilityCommand : ICommand<BookFastContext>
    {
        private readonly Facility facility;
        private readonly IFacilityMapper mapper;

        public CreateFacilityCommand(Facility facility, IFacilityMapper mapper)
        {
            this.facility = facility;
            this.mapper = mapper;
        }

        public Task ApplyAsync(BookFastContext model)
        {
            model.Facilities.Add(mapper.MapFrom(facility));
            return model.SaveChangesAsync();
        }
    }
}