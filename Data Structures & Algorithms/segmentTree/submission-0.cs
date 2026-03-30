class SegmentTree {
    public int L;
    public int R;
    public int M;
    public int sum;
    public SegmentTree left;
    public SegmentTree right;
    public SegmentTree(int[] nums) : this(nums, 0, nums.Length - 1) {
    }

    public SegmentTree(int[] nums, int inputL, int inputR){
        L = inputL;
        R = inputR;
        if(R == L){
            sum = nums[R];
        }
        else{
            M = (L + R) / 2;
            left = new SegmentTree(nums, L, M);
            right = new SegmentTree(nums, M + 1, R);
            sum = left.sum + right.sum;
        }
    }

    public void update(int index, int val) {
        if(L == R){
            sum = val;
        }
        else{
            if(index <= M){
                left.update(index, val);
            }
            else{
                right.update(index, val);
            }
            sum = left.sum + right.sum;
        }
    }

    public int query(int inputL, int inputR) {
        if((R == inputR) && (L == inputL)) { return sum;}
        if(inputR <= M){
            return left.query(inputL, inputR);
        }
        else if(inputL > M){
            return right.query(inputL, inputR);
        }
        else{
            return left.query(inputL, M) + right.query(M + 1, inputR);
        }
    }
}
