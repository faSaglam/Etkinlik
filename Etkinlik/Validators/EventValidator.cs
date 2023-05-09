

using Entities.Concreate.ViewModels;
using Entitites.Concreate;
using FluentValidation;

namespace EventUI.Validators
{
    public class EventCreateValidator:AbstractValidator<EventCreateDTO>
    {
     public EventCreateValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("İsim boş olamaz").NotEmpty().MaximumLength(50)
            .WithMessage("50 Karakterden fazla olamaz");
            RuleFor(e => e.CategoryID).NotNull().WithMessage("Bir kategori seçiniz");
            RuleFor(e => e.CityID).NotNull().WithMessage("Bir şehir seçiniz");
            RuleFor(e => e.DateTime).NotNull();
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.Quoto).NotNull().WithMessage("Kişi sayısı giriniz").GreaterThanOrEqualTo(5).WithMessage("En az 5 kişi olabilir");
        }
    }
    public class EventUpdateValidator : AbstractValidator<Event>
    {
        public EventUpdateValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("İsim boş olamaz").NotEmpty().MaximumLength(50)
              .WithMessage("50 Karakterden fazla olamaz");
            RuleFor(e => e.CategoryID).NotNull().WithMessage("Bir kategori seçiniz");
            RuleFor(e => e.CityID).NotNull().WithMessage("Bir şehir seçiniz");
            RuleFor(e => e.DateTime).NotNull();
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.Quoto).NotNull().WithMessage("Kişi sayısı giriniz").GreaterThanOrEqualTo(5).WithMessage("En az 5 kişi olabilir");
        }
    }
}
