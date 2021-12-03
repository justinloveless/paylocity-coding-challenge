import {RelationshipTypes} from "./relationship-types";

export interface EmployeeDependantRelation {
  dependantId: number,
  firstName: string,
  lastName: string,
  relationship: RelationshipTypes
}
