using System;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Commands
{
    internal class DeleteAccommodationCommand : ICommand<BookFastContext>
    {
        private readonly Guid accommodationId;

        public DeleteAccommodationCommand(Guid accommodationId)
        {
            this.accommodationId = accommodationId;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var accommodation = await model.Accommodations.FirstOrDefaultAsync(a => a.Id == accommodationId);
            if (accommodation != null)
            {
                model.Accommodations.Remove(accommodation);
                await model.SaveChangesAsync();
            }
        }
    }
}