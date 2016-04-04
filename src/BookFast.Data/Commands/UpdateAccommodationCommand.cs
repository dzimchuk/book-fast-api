using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Accommodation = BookFast.Contracts.Models.Accommodation;

namespace BookFast.Data.Commands
{
    internal class UpdateAccommodationCommand : ICommand<BookFastContext>
    {
        private readonly Accommodation accommodation;

        public UpdateAccommodationCommand(Accommodation accommodation)
        {
            this.accommodation = accommodation;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var existingAccommodation = await model.Accommodations.FirstOrDefaultAsync(a => a.Id == accommodation.Id);
            if (existingAccommodation != null)
            {
                existingAccommodation.Name = accommodation.Details.Name;
                existingAccommodation.Description = accommodation.Details.Description;
                existingAccommodation.RoomCount = accommodation.Details.RoomCount;

                await model.SaveChangesAsync();
            }
        }
    }
}