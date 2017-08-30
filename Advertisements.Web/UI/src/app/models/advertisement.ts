import {Resource} from './resource';

export class Advertisement{
  Id : number;
  Title : string;
  Description : string;
  Price : number;
  Resources : Resource[];
  ApplicationUserId : string;
  CategoryId : number;
  TypeId :number;
}