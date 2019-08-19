export class UserApi {
  public static getUsersApi(): string {
    return 'api/v1/Users';
  }

  public static getUserApi(email: string): string {
    return `api/v1/Users/${email}`;
  }
}