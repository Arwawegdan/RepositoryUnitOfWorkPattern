namespace Session.Shared; 
    public class EmployeeValidation : AbstractValidator<Employee>
    {
    int MaxLength = 20; 
    public EmployeeValidation()
    {
        RuleFor(e => e.Id).NotEmpty(); 

        RuleFor(e => e.Name).NotEmpty().WithMessage("Employee name must be not arwa");
        RuleFor(e => e.Name).Length(0,100).WithMessage("Employee name is too long");

        RuleFor(e => e.Age).NotNull();
        


        RuleFor(e => e.Mobile).NotEmpty();
        RuleFor(e => e.Mobile).Length(0,MaxLength); 

        RuleFor(e => e.Telephone).NotEmpty();
        RuleFor(e => e.Telephone).Length(0, MaxLength); 

        RuleFor(e => e.BirthDate).NotEmpty();
    }
}
