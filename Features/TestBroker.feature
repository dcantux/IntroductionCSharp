Feature: TestBroker

tests for broker impl


	@rabbitmq
	@critical
	@qatc:QATC1113
	Scenario: Send and Get Simple Message
	When I send a simple message Hello world
	Then the message Hello world is accessible