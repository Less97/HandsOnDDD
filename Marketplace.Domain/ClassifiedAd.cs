using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAdId Id { get; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            OwnerId = ownerId;
            Id = id;
            State = ClassifiedAdState.Inactive;
        }

        public void SetTitle(ClassifiedAdTitle title)
        {
            Title = title;
            EnsureValidState();
        }

        public void UpdateText(ClassifiedAdText text)
        {
            Text = text;
            EnsureValidState();
        } 
        public void UpdatePrice(Price price)
        {
            Price = price;
            EnsureValidState();
        }


        public void RequestToPublish()
        {
            State = ClassifiedAdState.PendingReview;
            EnsureValidState();
        }

        private void EnsureValidState()
        {
            var valid = Id != null && OwnerId != null && State switch
            {
                ClassifiedAdState.PendingReview => Title != null && Text != null && Price?.Amount > 0,
                ClassifiedAdState.Active => Title != null && Text != null && Price?.Amount > 0 && ApprovedBy != null,
                _ => true
            };
            if (!valid)
                throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
        }


        public UserId OwnerId { get; }
        public ClassifiedAdTitle Title { get; private set; }
        public ClassifiedAdText Text { get; private set; }
        public Price Price { get; private set; }
        public ClassifiedAdState State { get; private set; }
        public UserId ApprovedBy { get; private set; }

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }
    }
}
