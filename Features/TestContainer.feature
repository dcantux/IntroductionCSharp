Feature: TestContainer

Simple test for TestContainer impl


	@container
	@critical
	@qatc:QATC1111
	Scenario: Database Container
	Given I have a running MySQL Container
	Then the database should be accessible