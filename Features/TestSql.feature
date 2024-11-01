Feature: TestSQL

tests for sql impl


	@sql
	@critical
	@qatc:QATC1112
	Scenario: Get Data Users
	When I select the users table
	Then the data is accessible