export class Hero {

  constructor(
    public id: number,
    public name: string,
    public rating: number,
    public developer : string,
    public publisher : string,
    public year : number,
    public platforms: Array<string>,
    public tags?: Array<string>
  ) {  }

}
