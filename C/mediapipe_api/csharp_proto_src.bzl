def csharp_proto_src(name, proto_src, deps, import_prefix = ""):
    """Generate C# source code for *.proto

    Args:
      import_prefix: Directory where the generated source code is placed.
      proto_src: target .proto file path.
    """

    # e.g.
    #  If import_prefix is "Annotation" and proto_src is "mediapipe/framework/formats/annotation/rasterization", then
    #    csharp_out -> Rasterization.cs
    #    outdir -> $GENDIR/Annotation
    base_name = proto_src.split("/")[-1]
    csharp_out = _camelize(base_name.split(".")[0]) + ".cs"
    outdir = "$(GENDIR)" if len(import_prefix) == 0 else "$(GENDIR)/" + import_prefix

    native.genrule(
        name = name,
        srcs = deps + [
          "@com_google_protobuf//:well_known_protos",
        ],
        outs = [csharp_out],
        cmd = """
mkdir -p {outdir}
$(location @com_google_protobuf//:protoc) \
    --proto_path=. \
    --proto_path={outdir} \
    --proto_path=$$(pwd)/external/com_google_protobuf/src \
    --proto_path=$$(pwd)/external/com_google_mediapipe \
    --csharp_out={outdir} {}
mv {outdir}/{outfile} $$(dirname $(location {outfile}))
""".format(proto_src, outdir=outdir, outfile=csharp_out),
        tools = [
            "@com_google_protobuf//:protoc",
        ],
    )

def _camelize(str):
    return "".join([x.capitalize() for x in str.split("_")])

def _replace_suffix(string, old, new):
    """Returns a string with an old suffix replaced by a new suffix."""
    return string.endswith(old) and string[:-len(old)] + new or string
