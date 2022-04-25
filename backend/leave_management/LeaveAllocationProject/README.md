# Leave Allocation Project

docker image build --tag local/leave_management/leaveallocationproject:latest .

docker run --rm -it -p 5025:80 local/leave_management/leaveallocationproject:latest