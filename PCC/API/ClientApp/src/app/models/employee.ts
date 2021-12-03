import {EmployeeDependant} from "./employee-dependant";
import {EmployeeDependantRelation} from "./employee-dependant-relation";

export interface Employee {
  employeeId: number,
  firstName: string,
  lastName: string,
  salary: number
  dependants: EmployeeDependantRelation[]
}
