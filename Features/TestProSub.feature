Feature: TestProSub

tests for broker impl


	@pulsar
	@critical
	@qatc:QATC1113
	Scenario: Send and Get Simple Pro SUB
	When I send message 
	Then the message is accessible


	@pulsar
	@critical
	@qatc:QATC1114
	Scenario: Send and Get Complex Message
	When I send message with multiple fields
	Then the message multiple fields is verified


	@pulsar
	@critical
	@qatc:QATC1115
	Scenario: Produce and consume a message with a list
	When I send message with a list
	Then the message with a list is verified