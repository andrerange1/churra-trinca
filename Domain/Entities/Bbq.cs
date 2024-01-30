using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Events;

namespace Domain.Entities
{
    public class Bbq : AggregateRoot
    {
        public string Reason { get; set; }
        public BbqStatusEnum Status { get; set; }
        public DateTime Date { get; set; }
        public bool IsTrincasPaying { get; set; }

        public double MeatAmount { get; set; }
        public double VegetablesAmount { get; set; }
        public IList<string> PeopleId { get; set; }

        public Bbq()
        {
            PeopleId = new List<string>();
        }

        public void When(ThereIsSomeoneElseInTheMood @event)
        {
            Id = @event.Id.ToString();
            Date = @event.Date;
            Reason = @event.Reason;
            Status = BbqStatusEnum.New;
        }

        public void When(BbqStatusUpdated @event)
        {
            if (@event.GonnaHappen)
                Status = BbqStatusEnum.PendingConfirmations;
            else
            {
                Status = BbqStatusEnum.ItsNotGonnaHappen;
                PeopleId.Clear();
                MeatAmount = 0;
                VegetablesAmount = 0;
            }
                
            IsTrincasPaying = @event.TrincaWillPay;
        }

        public void When(InviteWasDeclined @event)
        {
            if (PeopleId.FirstOrDefault(x => x == @event.PersonId) is not null) //verifica se a pessoa ja tinha aceitado o convite anteriormente. se for o caso remove da lista e remove compras.
            {
                this.RemovePersonFood(@event.IsVeg);
                this.PeopleId.Remove(@event.PersonId);

                if (this.PeopleId.Count < 7)
                {
                    if (this.Status == BbqStatusEnum.Confirmed)
                        this.Status = BbqStatusEnum.PendingConfirmations;
                }
            }    
        }

        public object TakeSnapshot()
        {
            return new
            {
                Id,
                Date,
                IsTrincasPaying,
                Status = Status.ToString()
            };
        }

        public void When(InviteWasAccepted @event)
        {
            if (PeopleId.FirstOrDefault(x => x == @event.PersonId) is null) //verifica se a pessoa ja tinha aceitado o convite anteriormente. Se for o caso nao o adiciona novamente e nem adiciona compras novamente.
            {
                this.AddPersonFood(@event.IsVeg);
                this.PeopleId.Add(@event.PersonId);

                if (this.PeopleId.Count > 6)
                {
                    this.Status = BbqStatusEnum.Confirmed;
                }
            }
        }

        public void AddPersonFood(bool isVeg)
        {
            if (isVeg)
            {
                this.VegetablesAmount += 0.6;
            }
            else
            {
                this.VegetablesAmount += 0.3;
                this.MeatAmount += 0.3;
            }
        }
        public void RemovePersonFood(bool isVeg)
        {
            if (isVeg)
            {
                this.VegetablesAmount -= 0.6;
            }
            else
            {
                this.VegetablesAmount -= 0.3;
                this.MeatAmount -= 0.3;
            }
        }
    }
}
