export class UserApi {
  public static getUsersApi(): string {
    return 'api/v1/Users';
  }

  public static getPagingUsersApi(currentPage: number): string {
    return `api/v1/Users?currentPage=${currentPage}`;
  }

  public static getUserApi(id: string): string {
    return `api/v1/Users/${id}`;
  }
}