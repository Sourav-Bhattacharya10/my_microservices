# Leave Type Project

docker image build --tag local/leavetypeproject:latest .

docker run --rm -it -p 5023:80 local/leavetypeproject:latest