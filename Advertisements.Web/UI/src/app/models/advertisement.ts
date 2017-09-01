<<<<<<< HEAD
export class Advertisement{
  Id : number;
  Description : string;
  Myfield : string;
  Price : number;
  User : string;
  UserId : number;
  Category : string;
  CategoryId : number;
  Type : string;
=======
import {Resource} from './resource';

export class Advertisement{
  Id : number;
  Title : string;
  Description : string;
  Price : number;
  Resources : Resource[];
  ApplicationUserId : string;
  CategoryId : number;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
  TypeId :number;
}