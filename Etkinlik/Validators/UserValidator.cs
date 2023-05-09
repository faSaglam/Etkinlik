using Entities.Concreate.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EventUI.Validators
{
    public class UserValidator:AbstractValidator<UserRegisterDTO>
    {
        public UserValidator() 
        {
            
            RuleFor(u => u.FirstName).NotNull().WithMessage("İsim boş olamaz").NotEmpty().MaximumLength(30)
            .WithMessage("30 Karakterden fazla olamaz");
            RuleFor(u => u.LastName).NotNull().WithMessage("Soyad boş olamaz").NotEmpty().MaximumLength(30)
                    .WithMessage("30 Karakterden fazla olamaz");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Bir mail adresi giriniz");
            RuleFor(u => u.Password).NotEmpty()
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
                .Matches(@"[A-Z]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
                 .Matches(@"[0-9]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.");
           
            RuleFor(u => u.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor");
        }

    }
    public class UserUpdateValidator:AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.FirstName).NotNull().WithMessage("İsim boş olamaz").NotEmpty().MaximumLength(30)
             .WithMessage("30 Karakterden fazla olamaz");
            RuleFor(u => u.LastName).NotNull().WithMessage("Soyad boş olamaz").NotEmpty().MaximumLength(30)
                    .WithMessage("30 Karakterden fazla olamaz");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Bir mail adresi giriniz");
          

        }
    }
    public class UserPasswordUpdateValidator : AbstractValidator<UserPasswordUpdateDTO>
    {
        public UserPasswordUpdateValidator()
        {

            RuleFor(u => u.NewPassword).NotEmpty()
         .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
         .Matches(@"[A-Z]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
         .Matches(@"[a-z]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.")
         .Matches(@"[0-9]+").WithMessage("Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.");

            
        }
    }
}
