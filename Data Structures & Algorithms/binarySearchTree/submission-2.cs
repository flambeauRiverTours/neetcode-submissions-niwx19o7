class TreeMap {

    private TreeNode treeRoot;
    public TreeMap() {

    }

    public void Insert(int key, int val) {
        treeRoot = TreeInsert(key, val, treeRoot);
    }

    public TreeNode TreeInsert(int key, int val, TreeNode root){
        if(root == null) { return new TreeNode(key, val, null, null);}
        if(root.key == key){
            root.val = val;
        }
        else if(root.key > key){
            root.left = TreeInsert(key, val, root.left);
        }
        else{
            root.right = TreeInsert(key, val, root.right);
        }
        return root;
    }

    public int Get(int key) {
        return TreeSearch(key, treeRoot);
    }

    public int TreeSearch(int key, TreeNode root){
        if(root == null) {return -1;}
        if(root.key == key){
            return root.val;
        }
        if(root.key > key){
            return TreeSearch(key, root.left);
        }
        else{
            return TreeSearch(key, root.right);
        }
    }

    public int GetMin() {
        if(treeRoot == null) {return -1;}
        return GetTreeMin(treeRoot).val;
    }

    private TreeNode GetTreeMin(TreeNode root){
        if (root.left == null) {return root;}
        return GetTreeMin(root.left);
    }

    public int GetMax() {
        if(treeRoot == null) {return -1;}
        return GetTreeMax(treeRoot);
    }

    private int GetTreeMax(TreeNode root){
        if(root.right == null) {return root.val;}
        return GetTreeMax(root.right);
    }

    public void Remove(int key) {
        treeRoot = Remove(key, treeRoot);
    }

    private TreeNode Remove(int key, TreeNode root){
        if (root == null) {return null;}
        if(root.key > key){
            root.left = Remove(key, root.left);
        }
        if(root.key < key){
            root.right = Remove(key, root.right);
        }
        else{
            if(root.right == null){
                return root.left;
            }
            else if (root.left == null){
                return root.right;
            }
            else{
                TreeNode minFromRight = GetTreeMin(root.right);
                root.key = minFromRight.key;
                root.val = minFromRight.val;
                root.right = Remove(root.key, root.right);
            }
        }
        return root;
    }

    public List<int> GetInorderKeys() {
        List<int> inOrderList = new List<int>();
        InOrderKeyTraversal(treeRoot, inOrderList);
        return inOrderList;
    }

    private void InOrderKeyTraversal(TreeNode root, List<int> inOrderList){
        if(root == null){ return;}
        InOrderKeyTraversal(root.left, inOrderList);
        inOrderList.Add(root.key);
        InOrderKeyTraversal(root.right, inOrderList);
    }

}

public class TreeNode{
    public TreeNode(int inputKey, int inputval, TreeNode inputleft, TreeNode inputright){
        key = inputKey;
        val = inputval;
        left = inputleft;
        right = inputright;
    }
    public int key;
    public int val;
    public TreeNode left;
    public TreeNode right;
}
