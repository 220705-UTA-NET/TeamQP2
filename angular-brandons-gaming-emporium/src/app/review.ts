export class Review {

  constructor(
    public id: number,
    public content: string,
    public rating: number,
    public reviewer: string,
    public gameTitle: string,
    public reviewDate: string
  ) { }

}
