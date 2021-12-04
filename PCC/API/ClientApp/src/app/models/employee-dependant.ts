import {RelationshipTypes} from "./relationship-types";

export interface EmployeeDependant {
  dependantId: number,
  employeeId: number,
  firstName: string,
  lastName: string,
  relationship: RelationshipTypes
}
