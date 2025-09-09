Feature: Feature1

Scenario:Elements
   Given Open DEMOQA Website
   When I Click On 'Elements'
   Then I Validate the page 'Elements'

Scenario:TextBox in Elements 
	Given Open DEMOQA Website
    When I Click On 'Elements'
    And I Click On 'Text Box'
    Then I Validate the page 'Text Box'
    When I Enter the following details
      | FullName           | Email                 | CurrentAddress            | PermanentAddress        |
      | raj                | Raj@email.com         | Ayyappa society,Madhapur  | AP                      |
    Then I Validate the entered details
      | FullName           | Email                 | CurrentAddress           | PermanentAddress |
      | raj                | Raj@email.com         | Ayyappa society,Madhapur | AP               |

Scenario:Web Tables
    Given Open DEMOQA Website
    When I Click On 'Elements'
    And I Click On 'Web Tables'
    Then I Validate the page 'Web Tables'
    When I Click On 'Add'
    When I add the details in Web Tables
      | First Name | Last Name | Email           | Age | Salary  | Department     |
      | raj        | two       | Raj@email.com   | 25  | 1       | Tst            |
      | koti       | three     | Koti@email.com  | 30  | 5000    | HR             |
      | Nani       | four      | Nani@email.com  | 28  | 4000    | IT             |
      | Gani       | five      | Gani@email.com  | 30  | 5000    | HR             |
      | mani       | six       | mani@email.com  | 28  | 4000    | IT             |
   
    Then I Validate the Web Table details
      | First Name | Last Name | Email           | Age | Salary  | Department     |
      | raj        | two       | Raj@email.com   | 25  | 1       | Tst            |
      | koti       | three     | Koti@email.com  | 30  | 5000    | HR             |
      | Nani       | four      | Nani@email.com  | 28  | 4000    | IT             |
      | Gani       | five      | Gani@email.com  | 30  | 5000    | HR             |
      | mani       | six       | mani@email.com  | 28  | 4000    | IT             |


