PROJECT_DIR := src/QwantApp
UNIT_TEST_PROJECT_DIR := tests/QwantApp.Tests
INTEGRATION_TEST_PROJECT_DIR := tests/QwantApp.IntegrationTests
INPUT_FILE := $(PROJECT_DIR)/Inputs/input.txt

.PHONY: all build run test clean

all: build test run

build:
	dotnet build $(PROJECT_DIR)
	dotnet build $(UNIT_TEST_PROJECT_DIR)
	dotnet build $(INTEGRATION_TEST_PROJECT_DIR)

run: build
	dotnet run --project $(PROJECT_DIR) -- $(INPUT_FILE)

unit_test: build
	dotnet test $(UNIT_TEST_PROJECT_DIR)

integration_test: build
	dotnet test $(INTEGRATION_TEST_PROJECT_DIR)

test: unit_test integration_test

clean:
	dotnet clean $(PROJECT_DIR)
	dotnet clean $(UNIT_TEST_PROJECT_DIR)
	dotnet clean $(INTEGRATION_TEST_PROJECT_DIR)
