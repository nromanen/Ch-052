export class RestorePasswordViewModel {
    public NewPassword: string;
    public ConfNewPass: string;

    public constructor(NewPassword: string, ConfNewPass: string) {
        this.NewPassword = NewPassword;
        this.ConfNewPass = ConfNewPass;
    }
}