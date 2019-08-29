export class MajorApi {
  public static getMajorsApi() {
    return `api/v1/Majors`;
  }

  public static getMajorApi(id: string) {
    return `api/v1/Majors/${id}`;
  }

  public static changeActiveMajorApi(id: string) {
    return `api/v1/Majors/ChangeActive/${id}`;
  }
}
