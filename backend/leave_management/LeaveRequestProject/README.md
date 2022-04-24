# Leave Request Project

docker image build --tag local/leave_management/leaverequestproject:latest .

docker run --rm -it -p 5024:80 local/leave_management/leaverequestproject:latest