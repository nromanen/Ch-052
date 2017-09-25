export class UserRegisterModel {
    public constructor(public Name: string, public Surname: string,
        public Email: string, public Password: string, public ConfPassword: string)
    { }
}