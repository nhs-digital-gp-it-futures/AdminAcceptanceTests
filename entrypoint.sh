#!/bin/bash
runId=${RUN_ID:-0.1.0}
timeout=${SETUP_TIMEOUT:-600}
timestamp=$(date +%d-%m-%Y-%H-%M-%S)
additionalDotnetArgs=""

echo "Waiting for $PBURL to be ready..."

n=0
until [ "$n" -ge "$timeout" ]; do
  httpStatusCode=$(curl -I -s --insecure $PBURL | cat | head -n 1 | cut -d" " -f2)

  if [ "$httpStatusCode" = "200" ]; then echo "$PBURL was ready in $n seconds" && break; fi
  n=$((n+1)) 
  sleep 1
done

if [ "$n" -eq "$timeout" ]; then echo "$PBURL is not ready after $n seconds" && exit 1; fi


if [ -n "${TEST_RESULT_DIR}" ]; then
  echo "Directing test results to '$TEST_RESULT_DIR'"
  additionalDotnetArgs+="--logger \"trx;LogFileName=admin-$runId-$timestamp.trx\" --results-directory $TEST_RESULT_DIR "
fi

if [ -n "${TEST_FILTER}" ]; then
  echo "Running only tests annotated with '@$TEST_FILTER'"
  additionalDotnetArgs+="--filter TestCategory=$TEST_FILTER "
fi

cmd="dotnet test out/AdminAcceptanceTests.Tests.dll -v n $additionalDotnetArgs"
echo -e "\nRunning '$cmd' \n"
eval $cmd
