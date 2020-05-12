namespace FamilyMoney.Domain.Enums
{    public enum TypePaymentEnum
    {
        // [Display(Name="None", Description="Não informado")]
        None = 0,
        // [Display(Name="Cash", Description="Dinheiro")]
        Cash = 1,
        // [Display(Name="DebitCard", Description="Cartão de Débito")]
        DebitCard = 2,
        // [Display(Name="CreditCard", Description="Cartão de Crédito")]
        CreditCard = 3,
        // [Display(Name="BankSlip", Description="Boleto")]
        BankSlip = 4,
        // [Display(Name="Tranfer", Description="TED/DOC")]
        Tranfer = 5
    } 
}