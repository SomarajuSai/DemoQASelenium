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
      | raj                | Raj@email.com         | Ayyappa society,Madhapur  | AP                       |
    Then I Validate the entered details
      | FullName | Email         | CurrentAddress           | PermanentAddress |
      | raj      | Raj@email.com | Ayyappa society,Madhapur | AP               |

Scenario:Web Tables
    Given Open DEMOQA Website
    When I Click On 'Elements'
    And I Click On 'Web Tables'
    Then I Validate the page 'Web Tables'
    When I Click On 'Add'
    And I add the details in Web Tables
    | First Name | Last Name | Email         | Age | Salary | Department |
    | raj        | two       | Raj@email.com | 25  | 1      | Tst        |
    | KOTI       | THREE     | FH@EMAIL.com  | 26  | 2      | tst        |



    Then I Validate the Regestration Form details
    | First Name | Last Name | Email         | Age | Salary | Department    |
    | raj        | two       | Raj@email.com | 25  | 1      |     Tst       |

