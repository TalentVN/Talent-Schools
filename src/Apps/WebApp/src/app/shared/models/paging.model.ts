export class PagingModel<TModel> {
  currentPage: number;
  totalPages: number;
  data: TModel[];
}