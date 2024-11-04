Feature: TestBroker

tests for broker impl


	@rabbitmq
	@critical
	@qatc:QATC1113
	Scenario: Send and Get Simple Message
	When I send a simple message Hello world
	Then the message Hello world is accessible

	@rabbitmq
	@critical
	@qatc:QATC1114
	Scenario: Send and Get Complex Message
	When I send a complex message
	Then the message type complex is valided

	@rabbitmq
	@critical
	@qatc:QATC1115
	Scenario: Send and Get List Message
	When I send a list message
	Then the message type list is valided