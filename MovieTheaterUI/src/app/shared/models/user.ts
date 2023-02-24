export interface IUserSignupModel{
  userName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface IUserLoginModel{
  email: string;
  password: string;
  rememberMe: string;
}

export interface IUserModel{
  id: string;
  userName: string;
  email: string;
}
