# Leave Type Project

docker image build --tag local/leave_management/leavetypeproject:latest .

docker run --rm -it -p 5023:80 local/leave_management/leavetypeproject:latest