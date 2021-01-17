Feature: JourneyPlanner
	As a TFL Journey Planner user
	I should be able to plan, edit my jouney and view my recently planned jouneys
	On the Plan a journey Page

 
Scenario: JourneyPlanner_01_Verify that I can plan my journey with valid locations
	Given that tfl web page is loaded
	When I click on Plan a journey link
	And I fill-in 'SE12 0JP' into the From field
	And I fill-in 'SE1 1QW' into the To field	
	And I click on Plan my journey tab	
	Then View details button should be displayed

Scenario: JourneyPlanner_02_Verify that I cannot plan my journey with invalid locations
	Given that tfl web page is loaded
	When I click on Plan a journey link
	And I fill-in To and From fields below data
	| From    | To         |
	| 09090909| 7979797979 |
	And I click on Plan my journey tab	
	Then Journey result page should display 'Sorry, we can't find a journey matching your criteria'

Scenario Outline: JourneyPlanner_03_Verify that I cannot plan my journey with no locations
	Given that tfl web page is loaded
	When I click on Plan a journey link
	And I fill-in addresses into <From> and <To> fields
	And I click on Plan my journey tab
	Then my journey <ExpectedErrorMessage> should be created
	Examples: 
	| From      | To     |ExpectedErrorMessage       |
	|           |        |The From field is required.|
	|SE12 0JP   |        |The To field is required.  |
	|           |SE1 1QW |The From field is required.|


Scenario: JourneyPlanner_04_Verify that I can modify a journey on the journey result page
	Given that tfl web page is loaded
	When I click on Plan a journey link
	And I fill-in 'SE12 0JP' into the From field
	And I fill-in 'SE1 1QW' into the To field	
	And I click on Plan my journey tab
	And I click on Edit Journey link
	And I fill-in 'Lee Rail Station' into the From field
	And I click on Update Journey link	
	Then View details button should be displayed


Scenario: JourneyPlanner_05_Verify that I can view a list of my recently planned journeys
	Given that tfl web page is loaded
	When I click on Plan a journey link
	And I fill-in 'SE12 0JP' into the From field
	And I fill-in 'SE1 1QW' into the To field	
	And I click on Plan my journey tab	
	And I click on Recents tab	
	Then my recent journey 'SE12 0JP to SE1 1QW' should be displayed