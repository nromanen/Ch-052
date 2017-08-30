export class Resource{
    Id : number;
    Url : string;
    AdvertisementId :number;
    constructor (id:number, url:string, advertisementId:number){
      this.Id = id;
      this.Url = url;
      this.AdvertisementId = advertisementId;
    }
  }